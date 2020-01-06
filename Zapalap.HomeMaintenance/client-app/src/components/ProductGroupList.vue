<template>
  <div class="q-pa-md q-gutter-md row items-start">
    <q-card
      v-for="group in this.productGroups"
      :key="group.id"
      class="bg-secondary text-white"
    >
      <q-card-section class="text-h6">{{group.name}}</q-card-section>
      <q-card-section>{{group.description}}</q-card-section>
    </q-card>
  </div>
</template>

<script>
export default {
  name: 'ProductGroupList',
  components: ['QCard', 'QCardSection', 'QCardActions'],
  data () {
    return { productGroups: [] }
  },
  mounted () {
    this.$axios
      .get('api/productGroups')
      .then(response => (this.productGroups = response.data))
  }
}
</script>
